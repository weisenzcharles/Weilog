package org.charles.weilog.repository;

import org.charles.weilog.domain.PostMeta;
import org.springframework.data.jpa.repository.JpaRepository;

/**
 * 元数据仓库。
 */
public interface PostMetaRepository extends JpaRepository<PostMeta, Long> {
}
