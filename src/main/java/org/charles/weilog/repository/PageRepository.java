package org.charles.weilog.repository;

import org.charles.weilog.domain.Page;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

/**
 * 标签数据仓库。
 *
 * @author Charles
 */
public interface PageRepository extends JpaRepository<Page, Long>, JpaSpecificationExecutor<Page> {
}
