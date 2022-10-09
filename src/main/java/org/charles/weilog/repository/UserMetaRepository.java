package org.charles.weilog.repository;

import org.charles.weilog.domain.UserMeta;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

/**
 * 用户元数据仓储。
 */
public interface UserMetaRepository extends JpaRepository<UserMeta, Long>, JpaSpecificationExecutor<UserMeta> {
}